import { ABP, downloadBlob, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type { GetSystemColumnsInput, SystemColumnDto } from '../../../proxy/system-columns/models';
import { SystemColumnService } from '../../../proxy/system-columns/system-column.service';
@Component({
  selector: 'app-system-column',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './system-column.component.html',
  styles: [],
})
export class SystemColumnComponent implements OnInit {
  data: PagedResultDto<SystemColumnDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetSystemColumnsInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  isExportToExcelBusy = false;

  selected?: SystemColumnDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: SystemColumnService,
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

    const setData = (list: PagedResultDto<SystemColumnDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetSystemColumnsInput;
  }

  buildForm() {
    const {
      systemTableId,
      name,
      isKey,
      isSensitive,
      needMask,
      defaultValue,
      checkCode,
      related,
      allowUpdate,
      allowNull,
      allowEmpty,
      allowExport,
      allowSort,
      columnTypeCode,
      extendedInformation,
      dateA,
      dateD,
      sort,
      note,
      status,
    } = this.selected || {};

    this.form = this.fb.group({
      systemTableId: [systemTableId ?? null, []],
      name: [name ?? null, [Validators.required, Validators.maxLength(50)]],
      isKey: [isKey ?? false, [Validators.required]],
      isSensitive: [isSensitive ?? false, [Validators.required]],
      needMask: [needMask ?? false, [Validators.required]],
      defaultValue: [defaultValue ?? null, [Validators.maxLength(50)]],
      checkCode: [checkCode ?? false, [Validators.required]],
      related: [related ?? null, [Validators.maxLength(200)]],
      allowUpdate: [allowUpdate ?? false, [Validators.required]],
      allowNull: [allowNull ?? false, [Validators.required]],
      allowEmpty: [allowEmpty ?? false, [Validators.required]],
      allowExport: [allowExport ?? false, [Validators.required]],
      allowSort: [allowSort ?? false, [Validators.required]],
      columnTypeCode: [columnTypeCode ?? null, [Validators.required, Validators.maxLength(50)]],
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

  update(record: SystemColumnDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: SystemColumnDto) {
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
        downloadBlob(result, 'SystemColumn.xlsx');
      });
  }
}
