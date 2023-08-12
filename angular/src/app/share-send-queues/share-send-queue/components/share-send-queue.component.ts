import { ABP, downloadBlob, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetShareSendQueuesInput,
  ShareSendQueueDto,
} from '../../../proxy/share-send-queues/models';
import { ShareSendQueueService } from '../../../proxy/share-send-queues/share-send-queue.service';
@Component({
  selector: 'app-share-send-queue',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './share-send-queue.component.html',
  styles: [],
})
export class ShareSendQueueComponent implements OnInit {
  data: PagedResultDto<ShareSendQueueDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetShareSendQueuesInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  isExportToExcelBusy = false;

  selected?: ShareSendQueueDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: ShareSendQueueService,
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

    const setData = (list: PagedResultDto<ShareSendQueueDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetShareSendQueuesInput;
  }

  buildForm() {
    const {
      key1,
      key2,
      key3,
      sendTypeCode,
      fromAddr,
      toAddr,
      titleContents,
      contents,
      retry,
      sucess,
      suspend,
      dateSend,
      extendedInformation,
      dateA,
      dateD,
      sort,
      note,
      status,
    } = this.selected || {};

    this.form = this.fb.group({
      key1: [key1 ?? null, [Validators.required, Validators.maxLength(50)]],
      key2: [key2 ?? null, [Validators.required, Validators.maxLength(50)]],
      key3: [key3 ?? null, [Validators.required, Validators.maxLength(50)]],
      sendTypeCode: [sendTypeCode ?? null, [Validators.required, Validators.maxLength(50)]],
      fromAddr: [fromAddr ?? null, [Validators.maxLength(200)]],
      toAddr: [toAddr ?? null, [Validators.required, Validators.maxLength(500)]],
      titleContents: [titleContents ?? null, [Validators.maxLength(500)]],
      contents: [contents ?? null, [Validators.required]],
      retry: [retry ?? null, [Validators.required]],
      sucess: [sucess ?? false, [Validators.required]],
      suspend: [suspend ?? false, [Validators.required]],
      dateSend: [dateSend ? new Date(dateSend) : null, [Validators.required]],
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

  update(record: ShareSendQueueDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: ShareSendQueueDto) {
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
        downloadBlob(result, 'ShareSendQueue.xlsx');
      });
  }
}
