import { ABP, downloadBlob, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetResumeSnapshotsInput,
  ResumeSnapshotDto,
} from '../../../proxy/resume-snapshots/models';
import { ResumeSnapshotService } from '../../../proxy/resume-snapshots/resume-snapshot.service';
@Component({
  selector: 'app-resume-snapshot',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './resume-snapshot.component.html',
  styles: [],
})
export class ResumeSnapshotComponent implements OnInit {
  data: PagedResultDto<ResumeSnapshotDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetResumeSnapshotsInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  isExportToExcelBusy = false;

  selected?: ResumeSnapshotDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: ResumeSnapshotService,
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

    const setData = (list: PagedResultDto<ResumeSnapshotDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetResumeSnapshotsInput;
  }

  buildForm() {
    const {
      userMainId,
      resumeMainId,
      companyMainId,
      companyJobId,
      snapshot,
      userCompanyBindId,
      extendedInformation,
      dateA,
      dateD,
      sort,
      note,
      status,
    } = this.selected || {};

    this.form = this.fb.group({
      userMainId: [userMainId ?? null, []],
      resumeMainId: [resumeMainId ?? null, []],
      companyMainId: [companyMainId ?? null, []],
      companyJobId: [companyJobId ?? null, []],
      snapshot: [snapshot ?? null, [Validators.required]],
      userCompanyBindId: [userCompanyBindId ?? null, []],
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

  update(record: ResumeSnapshotDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: ResumeSnapshotDto) {
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
        downloadBlob(result, 'ResumeSnapshot.xlsx');
      });
  }
}
