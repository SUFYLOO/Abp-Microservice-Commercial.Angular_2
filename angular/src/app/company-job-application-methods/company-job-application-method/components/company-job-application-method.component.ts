import { ABP, downloadBlob, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetCompanyJobApplicationMethodsInput,
  CompanyJobApplicationMethodDto,
} from '../../../proxy/company-job-application-methods/models';
import { CompanyJobApplicationMethodService } from '../../../proxy/company-job-application-methods/company-job-application-method.service';
@Component({
  selector: 'app-company-job-application-method',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './company-job-application-method.component.html',
  styles: [],
})
export class CompanyJobApplicationMethodComponent implements OnInit {
  data: PagedResultDto<CompanyJobApplicationMethodDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetCompanyJobApplicationMethodsInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  isExportToExcelBusy = false;

  selected?: CompanyJobApplicationMethodDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: CompanyJobApplicationMethodService,
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

    const setData = (list: PagedResultDto<CompanyJobApplicationMethodDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetCompanyJobApplicationMethodsInput;
  }

  buildForm() {
    const {
      companyMainId,
      companyJobId,
      orgDept,
      orgContactPerson,
      orgContactMail,
      toRespondDay,
      toRespond,
      systemSendResume,
      displayMail,
      telephone,
      personally,
      personallyAddress,
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
      orgDept: [orgDept ?? null, [Validators.maxLength(500)]],
      orgContactPerson: [orgContactPerson ?? null, [Validators.maxLength(50)]],
      orgContactMail: [orgContactMail ?? null, [Validators.maxLength(500)]],
      toRespondDay: [toRespondDay ?? null, []],
      toRespond: [toRespond ?? false, []],
      systemSendResume: [systemSendResume ?? false, []],
      displayMail: [displayMail ?? false, []],
      telephone: [telephone ?? null, [Validators.maxLength(50)]],
      personally: [personally ?? null, [Validators.maxLength(200)]],
      personallyAddress: [personallyAddress ?? null, [Validators.maxLength(200)]],
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

  update(record: CompanyJobApplicationMethodDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: CompanyJobApplicationMethodDto) {
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
        downloadBlob(result, 'CompanyJobApplicationMethod.xlsx');
      });
  }
}
