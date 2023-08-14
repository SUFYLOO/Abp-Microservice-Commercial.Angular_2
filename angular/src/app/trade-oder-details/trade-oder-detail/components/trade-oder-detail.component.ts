import { ABP, downloadBlob, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetTradeOderDetailsInput,
  TradeOderDetailDto,
} from '../../../proxy/trade-oder-details/models';
import { TradeOderDetailService } from '../../../proxy/trade-oder-details/trade-oder-detail.service';
@Component({
  selector: 'app-trade-oder-detail',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './trade-oder-detail.component.html',
  styles: [],
})
export class TradeOderDetailComponent implements OnInit {
  data: PagedResultDto<TradeOderDetailDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetTradeOderDetailsInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  isExportToExcelBusy = false;

  selected?: TradeOderDetailDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: TradeOderDetailService,
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

    const setData = (list: PagedResultDto<TradeOderDetailDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetTradeOderDetailsInput;
  }

  buildForm() {
    const {
      tradeOrderId,
      tradeProductId,
      unitPrice,
      quantity,
      orderDetailStateCode,
      extendedInformation,
      dateA,
      dateD,
      sort,
      note,
      status,
    } = this.selected || {};

    this.form = this.fb.group({
      tradeOrderId: [tradeOrderId ?? null, []],
      tradeProductId: [tradeProductId ?? null, []],
      unitPrice: [unitPrice ?? null, []],
      quantity: [quantity ?? null, []],
      orderDetailStateCode: [
        orderDetailStateCode ?? null,
        [Validators.required, Validators.maxLength(50)],
      ],
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

  update(record: TradeOderDetailDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: TradeOderDetailDto) {
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
        downloadBlob(result, 'TradeOderDetail.xlsx');
      });
  }
}
