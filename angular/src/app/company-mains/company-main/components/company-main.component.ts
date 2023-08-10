import { ABP, downloadBlob, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type { GetCompanyMainsInput, CompanyMainDto } from '../../../proxy/company-mains/models';
import { CompanyMainService } from '../../../proxy/company-mains/company-main.service';
@Component({
  selector: 'app-company-main',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './company-main.component.html',
  styles: [],
})
export class CompanyMainComponent implements OnInit {
  data: PagedResultDto<CompanyMainDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetCompanyMainsInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  isExportToExcelBusy = false;

  selected?: CompanyMainDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: CompanyMainService,
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

    const setData = (list: PagedResultDto<CompanyMainDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetCompanyMainsInput;
  }

  buildForm() {
    const {
      name,
      compilation,
      officePhone,
      faxPhone,
      address,
      principal,
      allowSearch,
      extendedInformation,
      dateA,
      dateD,
      note,
      sort,
      status,
      industryCategory,
      companyUrl,
      capitalAmount,
      hideCapitalAmount,
      companyScaleCode,
      hidePrincipal,
      companyUserId,
      companyProfile,
      businessPhilosophy,
      operatingItems,
      welfareSystem,
      matching,
      contractPass,
    } = this.selected || {};

    this.form = this.fb.group({
      name: [name ?? null, [Validators.required, Validators.maxLength(50)]],
      compilation: [compilation ?? null, [Validators.maxLength(50)]],
      officePhone: [officePhone ?? null, [Validators.maxLength(50)]],
      faxPhone: [faxPhone ?? null, [Validators.maxLength(50)]],
      address: [address ?? null, [Validators.maxLength(50)]],
      principal: [principal ?? null, [Validators.maxLength(50)]],
      allowSearch: [allowSearch ?? false, []],
      extendedInformation: [extendedInformation ?? null, [Validators.maxLength(500)]],
      dateA: [dateA ? new Date(dateA) : null, [Validators.required]],
      dateD: [dateD ? new Date(dateD) : null, [Validators.required]],
      note: [note ?? null, [Validators.maxLength(500)]],
      sort: [sort ?? null, [Validators.required]],
      status: [status ?? null, [Validators.required, Validators.maxLength(50)]],
      industryCategory: [
        industryCategory ?? null,
        [Validators.required, Validators.maxLength(500)],
      ],
      companyUrl: [companyUrl ?? null, [Validators.maxLength(200)]],
      capitalAmount: [capitalAmount ?? null, []],
      hideCapitalAmount: [hideCapitalAmount ?? false, []],
      companyScaleCode: [companyScaleCode ?? null, [Validators.required, Validators.maxLength(50)]],
      hidePrincipal: [hidePrincipal ?? false, []],
      companyUserId: [companyUserId ?? null, []],
      companyProfile: [companyProfile ?? null, [Validators.maxLength(500)]],
      businessPhilosophy: [businessPhilosophy ?? null, [Validators.maxLength(500)]],
      operatingItems: [operatingItems ?? null, [Validators.maxLength(500)]],
      welfareSystem: [welfareSystem ?? null, [Validators.maxLength(500)]],
      matching: [matching ?? false, []],
      contractPass: [contractPass ?? false, []],
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

  update(record: CompanyMainDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: CompanyMainDto) {
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
        downloadBlob(result, 'CompanyMain.xlsx');
      });
  }
}
