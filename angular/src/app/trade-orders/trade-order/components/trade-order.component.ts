import { ABP, downloadBlob, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type { GetTradeOrdersInput, TradeOrderDto } from '../../../proxy/trade-orders/models';
import { TradeOrderService } from '../../../proxy/trade-orders/trade-order.service';
@Component({
  selector: 'app-trade-order',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './trade-order.component.html',
  styles: [],
})
export class TradeOrderComponent implements OnInit {
  data: PagedResultDto<TradeOrderDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetTradeOrdersInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  isExportToExcelBusy = false;

  selected?: TradeOrderDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: TradeOrderService,
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

    const setData = (list: PagedResultDto<TradeOrderDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetTradeOrdersInput;
  }

  buildForm() {
    const {
      keyId,
      orderNumber,
      dateOrder,
      dateNeed,
      dateDelivery,
      deliveryMethodCode,
      deliveryZipCode,
      deliveryCityCode,
      deliveryAreaCode,
      deliveryAddress,
      deliveryFee,
      userName,
      orderStateCode,
      extendedInformation,
      dateA,
      dateD,
      sort,
      note,
      status,
    } = this.selected || {};

    this.form = this.fb.group({
      keyId: [keyId ?? null, []],
      orderNumber: [orderNumber ?? null, [Validators.required, Validators.maxLength(50)]],
      dateOrder: [dateOrder ? new Date(dateOrder) : null, []],
      dateNeed: [dateNeed ? new Date(dateNeed) : null, []],
      dateDelivery: [dateDelivery ? new Date(dateDelivery) : null, []],
      deliveryMethodCode: [deliveryMethodCode ?? null, [Validators.maxLength(50)]],
      deliveryZipCode: [deliveryZipCode ?? null, [Validators.maxLength(50)]],
      deliveryCityCode: [deliveryCityCode ?? null, [Validators.maxLength(50)]],
      deliveryAreaCode: [deliveryAreaCode ?? null, [Validators.maxLength(50)]],
      deliveryAddress: [deliveryAddress ?? null, [Validators.maxLength(50)]],
      deliveryFee: [deliveryFee ?? null, []],
      userName: [userName ?? null, [Validators.maxLength(50)]],
      orderStateCode: [orderStateCode ?? null, [Validators.required, Validators.maxLength(50)]],
      extendedInformation: [extendedInformation ?? null, [Validators.maxLength(500)]],
      dateA: [dateA ? new Date(dateA) : null, []],
      dateD: [dateD ? new Date(dateD) : null, []],
      sort: [sort ?? null, []],
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
      ? this.service.update(this.selected.id, {
          ...this.form.value,
          concurrencyStamp: this.selected.concurrencyStamp,
        })
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

  update(record: TradeOrderDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: TradeOrderDto) {
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
        downloadBlob(result, 'TradeOrder.xlsx');
      });
  }
}
