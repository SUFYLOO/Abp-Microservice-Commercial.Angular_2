import { ABP, downloadBlob, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type { GetShareDefaultsInput, ShareDefaultDto } from '../../../proxy/share-defaults/models';
import { ShareDefaultService } from '../../../proxy/share-defaults/share-default.service';
@Component({
  selector: 'app-share-default',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './share-default.component.html',
  styles: [],
})
export class ShareDefaultComponent implements OnInit {
  data: PagedResultDto<ShareDefaultDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetShareDefaultsInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  isExportToExcelBusy = false;

  selected?: ShareDefaultDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: ShareDefaultService,
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

    const setData = (list: PagedResultDto<ShareDefaultDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetShareDefaultsInput;
  }

  buildForm() {
    const {
      groupCode,
      key1,
      key2,
      key3,
      name,
      fieldKey,
      fieldValue,
      columnTypeCode,
      formTypeCode,
      systemUse,
      extendedInformation,
      dateA,
      dateD,
      sort,
      note,
      status,
    } = this.selected || {};

    this.form = this.fb.group({
      groupCode: [groupCode ?? null, [Validators.required, Validators.maxLength(50)]],
      key1: [key1 ?? null, [Validators.maxLength(50)]],
      key2: [key2 ?? null, [Validators.maxLength(50)]],
      key3: [key3 ?? null, [Validators.maxLength(50)]],
      name: [name ?? null, [Validators.required, Validators.maxLength(200)]],
      fieldKey: [fieldKey ?? null, [Validators.required, Validators.maxLength(50)]],
      fieldValue: [fieldValue ?? null, [Validators.maxLength(500)]],
      columnTypeCode: [columnTypeCode ?? null, [Validators.required, Validators.maxLength(50)]],
      formTypeCode: [formTypeCode ?? null, [Validators.required, Validators.maxLength(50)]],
      systemUse: [systemUse ?? false, [Validators.required]],
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

  update(record: ShareDefaultDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: ShareDefaultDto) {
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
        downloadBlob(result, 'ShareDefault.xlsx');
      });
  }
}
