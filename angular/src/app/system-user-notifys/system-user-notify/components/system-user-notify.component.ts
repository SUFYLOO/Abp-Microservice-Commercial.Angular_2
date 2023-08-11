import { ABP, downloadBlob, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetSystemUserNotifysInput,
  SystemUserNotifyDto,
} from '../../../proxy/system-user-notifys/models';
import { SystemUserNotifyService } from '../../../proxy/system-user-notifys/system-user-notify.service';
@Component({
  selector: 'app-system-user-notify',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './system-user-notify.component.html',
  styles: [],
})
export class SystemUserNotifyComponent implements OnInit {
  data: PagedResultDto<SystemUserNotifyDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetSystemUserNotifysInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  isExportToExcelBusy = false;

  selected?: SystemUserNotifyDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: SystemUserNotifyService,
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

    const setData = (list: PagedResultDto<SystemUserNotifyDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetSystemUserNotifysInput;
  }

  buildForm() {
    const {
      userMainId,
      keyId,
      keyName,
      notifyTypeCode,
      appName,
      appCode,
      titleContents,
      contents,
      isRead,
      extendedInformation,
      dateA,
      dateD,
      sort,
      note,
      status,
    } = this.selected || {};

    this.form = this.fb.group({
      userMainId: [userMainId ?? null, [Validators.required]],
      keyId: [keyId ?? null, [Validators.maxLength(50)]],
      keyName: [keyName ?? null, [Validators.maxLength(50)]],
      notifyTypeCode: [notifyTypeCode ?? null, [Validators.required, Validators.maxLength(50)]],
      appName: [appName ?? null, [Validators.required, Validators.maxLength(50)]],
      appCode: [appCode ?? null, [Validators.required, Validators.maxLength(50)]],
      titleContents: [titleContents ?? null, [Validators.required, Validators.maxLength(500)]],
      contents: [contents ?? null, [Validators.required, Validators.maxLength(500)]],
      isRead: [isRead ?? false, [Validators.required]],
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

  update(record: SystemUserNotifyDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: SystemUserNotifyDto) {
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
        downloadBlob(result, 'SystemUserNotify.xlsx');
      });
  }
}
