import { ABP, downloadBlob, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type { GetSystemTablesInput, SystemTableDto } from '../../../proxy/system-tables/models';
import { SystemTableService } from '../../../proxy/system-tables/system-table.service';
@Component({
  selector: 'app-system-table',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './system-table.component.html',
  styles: [],
})
export class SystemTableComponent implements OnInit {
  data: PagedResultDto<SystemTableDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetSystemTablesInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  isExportToExcelBusy = false;

  selected?: SystemTableDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: SystemTableService,
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

    const setData = (list: PagedResultDto<SystemTableDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetSystemTablesInput;
  }

  buildForm() {
    const {
      name,
      allowInsert,
      allowUpdate,
      allowDelete,
      allowSelect,
      allowExport,
      allowImport,
      allowPage,
      allowSort,
      extendedInformation,
      dateA,
      dateD,
      sort,
      note,
      status,
    } = this.selected || {};

    this.form = this.fb.group({
      name: [name ?? null, [Validators.required, Validators.maxLength(50)]],
      allowInsert: [allowInsert ?? false, [Validators.required]],
      allowUpdate: [allowUpdate ?? false, [Validators.required]],
      allowDelete: [allowDelete ?? false, [Validators.required]],
      allowSelect: [allowSelect ?? false, [Validators.required]],
      allowExport: [allowExport ?? false, [Validators.required]],
      allowImport: [allowImport ?? false, [Validators.required]],
      allowPage: [allowPage ?? false, [Validators.required]],
      allowSort: [allowSort ?? false, [Validators.required]],
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

  update(record: SystemTableDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: SystemTableDto) {
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
        downloadBlob(result, 'SystemTable.xlsx');
      });
  }
}
