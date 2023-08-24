import { ABP, downloadBlob, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetResumeEducationssInput,
  ResumeEducationsDto,
} from '../../../proxy/resume-educationss/models';
import { ResumeEducationsService } from '../../../proxy/resume-educationss/resume-educations.service';
@Component({
  selector: 'app-resume-educations',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './resume-educations.component.html',
  styles: [],
})
export class ResumeEducationsComponent implements OnInit {
  data: PagedResultDto<ResumeEducationsDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetResumeEducationssInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  isExportToExcelBusy = false;

  selected?: ResumeEducationsDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: ResumeEducationsService,
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

    const setData = (list: PagedResultDto<ResumeEducationsDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetResumeEducationssInput;
  }

  buildForm() {
    const {
      resumeMainId,
      educationLevelCode,
      schoolCode,
      schoolName,
      night,
      working,
      majorDepartmentName,
      majorDepartmentCategory,
      minorDepartmentName,
      minorDepartmentCategory,
      graduationCode,
      domestic,
      countryCode,
      extendedInformation,
      dateA,
      dateD,
      sort,
      note,
      status,
    } = this.selected || {};

    this.form = this.fb.group({
      resumeMainId: [resumeMainId ?? null, []],
      educationLevelCode: [
        educationLevelCode ?? null,
        [Validators.required, Validators.maxLength(50)],
      ],
      schoolCode: [schoolCode ?? null, [Validators.required, Validators.maxLength(50)]],
      schoolName: [schoolName ?? null, [Validators.required, Validators.maxLength(200)]],
      night: [night ?? false, [Validators.required]],
      working: [working ?? false, [Validators.required]],
      majorDepartmentName: [
        majorDepartmentName ?? null,
        [Validators.required, Validators.maxLength(50)],
      ],
      majorDepartmentCategory: [
        majorDepartmentCategory ?? null,
        [Validators.required, Validators.maxLength(500)],
      ],
      minorDepartmentName: [
        minorDepartmentName ?? null,
        [Validators.required, Validators.maxLength(50)],
      ],
      minorDepartmentCategory: [
        minorDepartmentCategory ?? null,
        [Validators.required, Validators.maxLength(500)],
      ],
      graduationCode: [graduationCode ?? null, [Validators.required, Validators.maxLength(50)]],
      domestic: [domestic ?? false, [Validators.required]],
      countryCode: [countryCode ?? null, [Validators.required, Validators.maxLength(50)]],
      extendedInformation: [extendedInformation ?? null, [Validators.maxLength(500)]],
      dateA: [dateA ? new Date(dateA) : null, []],
      dateD: [dateD ? new Date(dateD) : null, []],
      sort: [sort ?? null, []],
      note: [note ?? null, [Validators.maxLength(500)]],
      status: [status ?? null, [Validators.maxLength(50)]],
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

  update(record: ResumeEducationsDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: ResumeEducationsDto) {
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
        downloadBlob(result, 'ResumeEducations.xlsx');
      });
  }
}
