import { ABP, downloadBlob, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetCompanyJobContentsInput,
  CompanyJobContentDto,
} from '../../../proxy/company-job-contents/models';
import { CompanyJobContentService } from '../../../proxy/company-job-contents/company-job-content.service';
@Component({
  selector: 'app-company-job-content',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './company-job-content.component.html',
  styles: [],
})
export class CompanyJobContentComponent implements OnInit {
  data: PagedResultDto<CompanyJobContentDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetCompanyJobContentsInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  isExportToExcelBusy = false;

  selected?: CompanyJobContentDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: CompanyJobContentService,
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

    const setData = (list: PagedResultDto<CompanyJobContentDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetCompanyJobContentsInput;
  }

  buildForm() {
    const {
      companyMainId,
      companyJobId,
      name,
      jobTypeCode,
      peopleRequiredNumber,
      peopleRequiredNumberUnlimited,
      jobType,
      jobTypeContent,
      salaryPayTypeCode,
      salaryMin,
      salaryMax,
      salaryUp,
      workPlace,
      workHours,
      workHoursCustom,
      workShift,
      workRemoteAllow,
      workRemoteTypeCode,
      workRemoteDescript,
      businessTrip,
      holidaySystemCode,
      dispatched,
      workDayCode,
      workIdentity,
      disabilityCategory,
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
      name: [name ?? null, [Validators.required, Validators.maxLength(50)]],
      jobTypeCode: [jobTypeCode ?? null, [Validators.required, Validators.maxLength(50)]],
      peopleRequiredNumber: [peopleRequiredNumber ?? null, []],
      peopleRequiredNumberUnlimited: [peopleRequiredNumberUnlimited ?? false, []],
      jobType: [jobType ?? null, [Validators.maxLength(500)]],
      jobTypeContent: [jobTypeContent ?? null, [Validators.maxLength(4000)]],
      salaryPayTypeCode: [
        salaryPayTypeCode ?? null,
        [Validators.required, Validators.maxLength(50)],
      ],
      salaryMin: [salaryMin ?? null, []],
      salaryMax: [salaryMax ?? null, []],
      salaryUp: [salaryUp ?? false, []],
      workPlace: [workPlace ?? null, [Validators.maxLength(500)]],
      workHours: [workHours ?? null, [Validators.maxLength(500)]],
      workHoursCustom: [workHoursCustom ?? null, [Validators.maxLength(200)]],
      workShift: [workShift ?? false, []],
      workRemoteAllow: [workRemoteAllow ?? false, []],
      workRemoteTypeCode: [
        workRemoteTypeCode ?? null,
        [Validators.required, Validators.maxLength(50)],
      ],
      workRemoteDescript: [workRemoteDescript ?? null, [Validators.maxLength(500)]],
      businessTrip: [businessTrip ?? false, []],
      holidaySystemCode: [
        holidaySystemCode ?? null,
        [Validators.required, Validators.maxLength(50)],
      ],
      dispatched: [dispatched ?? false, []],
      workDayCode: [workDayCode ?? null, [Validators.required, Validators.maxLength(50)]],
      workIdentity: [workIdentity ?? null, [Validators.maxLength(500)]],
      disabilityCategory: [disabilityCategory ?? null, [Validators.maxLength(4000)]],
      extendedInformation: [extendedInformation ?? null, [Validators.maxLength(500)]],
      dateA: [dateA ?? '1900/1/1', []],
      dateD: [dateD ?? '2099/12/31', []],
      sort: [sort ?? '9', []],
      note: [note ?? null, [Validators.maxLength(500)]],
      status: [status ?? '1', [Validators.maxLength(50)]],
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

  update(record: CompanyJobContentDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: CompanyJobContentDto) {
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
        downloadBlob(result, 'CompanyJobContent.xlsx');
      });
  }
}
