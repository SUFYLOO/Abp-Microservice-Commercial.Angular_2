import { ABP, downloadBlob, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetResumeExperiencessInput,
  ResumeExperiencesDto,
} from '../../../proxy/resume-experiencess/models';
import { ResumeExperiencesService } from '../../../proxy/resume-experiencess/resume-experiences.service';
@Component({
  selector: 'app-resume-experiences',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './resume-experiences.component.html',
  styles: [],
})
export class ResumeExperiencesComponent implements OnInit {
  data: PagedResultDto<ResumeExperiencesDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetResumeExperiencessInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  isExportToExcelBusy = false;

  selected?: ResumeExperiencesDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: ResumeExperiencesService,
    private confirmation: ConfirmationService,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    const getData = (query: ABP.PageQueryParams) =>
      this.service.getList({
        ...query,
        ...this.filters,
        filterText: query.filter,
      });

    const setData = (list: PagedResultDto<ResumeExperiencesDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetResumeExperiencessInput;
  }

  buildForm() {
    const {
      resumeMainId,
      name,
      workNatureCode,
      hideCompanyName,
      industryCategoryCode,
      jobName,
      jobType,
      working,
      workPlaceCode,
      hideWorkSalary,
      salaryPayTypeCode,
      currencyTypeCode,
      salary1,
      salary2,
      companyScaleCode,
      companyManagementNumberCode,
      extendedInformation,
      dateA,
      dateD,
      sort,
      note,
      status,
    } = this.selected || {};

    this.form = this.fb.group({
      resumeMainId: [resumeMainId ?? null, []],
      name: [name ?? null, [Validators.required, Validators.maxLength(50)]],
      workNatureCode: [workNatureCode ?? null, [Validators.required, Validators.maxLength(50)]],
      hideCompanyName: [hideCompanyName ?? false, [Validators.required]],
      industryCategoryCode: [
        industryCategoryCode ?? null,
        [Validators.required, Validators.maxLength(500)],
      ],
      jobName: [jobName ?? null, [Validators.required, Validators.maxLength(50)]],
      jobType: [jobType ?? null, [Validators.maxLength(500)]],
      working: [working ?? false, [Validators.required]],
      workPlaceCode: [workPlaceCode ?? null, [Validators.maxLength(500)]],
      hideWorkSalary: [hideWorkSalary ?? false, []],
      salaryPayTypeCode: [
        salaryPayTypeCode ?? null,
        [Validators.required, Validators.maxLength(50)],
      ],
      currencyTypeCode: [currencyTypeCode ?? null, [Validators.required, Validators.maxLength(50)]],
      salary1: [salary1 ?? null, []],
      salary2: [salary2 ?? null, []],
      companyScaleCode: [companyScaleCode ?? null, [Validators.required, Validators.maxLength(50)]],
      companyManagementNumberCode: [
        companyManagementNumberCode ?? null,
        [Validators.required, Validators.maxLength(50)],
      ],
      extendedInformation: [extendedInformation ?? null, [Validators.maxLength(500)]],
      dateA: [dateA ? new Date(dateA) : null, [Validators.required]],
      dateD: [dateD ? new Date(dateD) : null, [Validators.required]],
      sort: [sort ?? null, [Validators.required]],
      note: [note ?? null, [Validators.maxLength(500)]],
      status: [status ?? null, [Validators.required, Validators.maxLength(50)]],
    });
  }

  hideForm() {
    this.isModalOpen = false;
    this.form.reset();
  }

  showForm() {
    this.buildForm();
    this.isModalOpen = true;
  }

  submitForm() {
    if (this.form.invalid) return;

    const request = this.selected
      ? this.service.update(this.selected.id, this.form.value)
      : this.service.create(this.form.value);

    this.isModalBusy = true;

    request
      .pipe(
        finalize(() => (this.isModalBusy = false)),
        tap(() => this.hideForm())
      )
      .subscribe(this.list.get);
  }

  create() {
    this.selected = undefined;
    this.showForm();
  }

  update(record: ResumeExperiencesDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: ResumeExperiencesDto) {
    this.confirmation
      .warn('::DeleteConfirmationMessage', '::AreYouSure', { messageLocalizationParams: [] })
      .pipe(
        filter(status => status === Confirmation.Status.confirm),
        switchMap(() => this.service.delete(record.id))
      )
      .subscribe(this.list.get);
  }

  exportToExcel() {
    this.isExportToExcelBusy = true;
    this.service
      .getDownloadToken()
      .pipe(
        switchMap(({ token }) =>
          this.service.getListAsExcelFile({ downloadToken: token, filterText: this.list.filter })
        ),
        finalize(() => (this.isExportToExcelBusy = false))
      )
      .subscribe(result => {
        downloadBlob(result, 'ResumeExperiences.xlsx');
      });
  }
}
