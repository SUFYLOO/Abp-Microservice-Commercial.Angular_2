import { ABP, downloadBlob, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetResumeExperiencesJobsInput,
  ResumeExperiencesJobDto,
} from '../../../proxy/resume-experiences-jobs/models';
import { ResumeExperiencesJobService } from '../../../proxy/resume-experiences-jobs/resume-experiences-job.service';
@Component({
  selector: 'app-resume-experiences-job',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './resume-experiences-job.component.html',
  styles: [],
})
export class ResumeExperiencesJobComponent implements OnInit {
  data: PagedResultDto<ResumeExperiencesJobDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetResumeExperiencesJobsInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  isExportToExcelBusy = false;

  selected?: ResumeExperiencesJobDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: ResumeExperiencesJobService,
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

    const setData = (list: PagedResultDto<ResumeExperiencesJobDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetResumeExperiencesJobsInput;
  }

  buildForm() {
    const {
      resumeMainId,
      resumeExperiencesId,
      jobType,
      year,
      month,
      extendedInformation,
      dateA,
      dateD,
      sort,
      note,
      status,
    } = this.selected || {};

    this.form = this.fb.group({
      resumeMainId: [resumeMainId ?? null, []],
      resumeExperiencesId: [resumeExperiencesId ?? null, []],
      jobType: [jobType ?? null, [Validators.required, Validators.maxLength(500)]],
      year: [year ?? null, []],
      month: [month ?? null, []],
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

  update(record: ResumeExperiencesJobDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: ResumeExperiencesJobDto) {
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
        downloadBlob(result, 'ResumeExperiencesJob.xlsx');
      });
  }
}
