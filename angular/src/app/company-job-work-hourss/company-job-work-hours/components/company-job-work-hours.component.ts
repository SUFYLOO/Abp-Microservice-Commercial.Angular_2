import { ABP, downloadBlob, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetCompanyJobWorkHourssInput,
  CompanyJobWorkHoursDto,
} from '../../../proxy/company-job-work-hourss/models';
import { CompanyJobWorkHoursService } from '../../../proxy/company-job-work-hourss/company-job-work-hours.service';
@Component({
  selector: 'app-company-job-work-hours',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './company-job-work-hours.component.html',
  styles: [],
})
export class CompanyJobWorkHoursComponent implements OnInit {
  data: PagedResultDto<CompanyJobWorkHoursDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetCompanyJobWorkHourssInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  isExportToExcelBusy = false;

  selected?: CompanyJobWorkHoursDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: CompanyJobWorkHoursService,
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

    const setData = (list: PagedResultDto<CompanyJobWorkHoursDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetCompanyJobWorkHourssInput;
  }

  buildForm() {
    const {
      companyMainId,
      companyJobId,
      workHoursCode,
      extendedInformation,
      dateA,
      dateD,
      sort,
      note,
      status,
    } = this.selected || {};

    this.form = this.fb.group({
      companyMainId: [companyMainId ?? null, []],
      companyJobId: [companyJobId ?? null, []],
      workHoursCode: [workHoursCode ?? null, [Validators.required, Validators.maxLength(50)]],
      extendedInformation: [extendedInformation ?? null, []],
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

  update(record: CompanyJobWorkHoursDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: CompanyJobWorkHoursDto) {
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
        downloadBlob(result, 'CompanyJobWorkHours.xlsx');
      });
  }
}
