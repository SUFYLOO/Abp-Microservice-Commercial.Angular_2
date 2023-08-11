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
      workHour,
      workShift,
      workRemoteAllow,
      workRemoteTypeCode,
      workRemote,
      workDifferentPlaces,
      holidaySystemCode,
      workDayCode,
      workIdentityCode,
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
      jobType: [jobType ?? null, [Validators.maxLength(200)]],
      jobTypeContent: [jobTypeContent ?? null, []],
      salaryPayTypeCode: [
        salaryPayTypeCode ?? null,
        [Validators.required, Validators.maxLength(50)],
      ],
      salaryMin: [salaryMin ?? null, []],
      salaryMax: [salaryMax ?? null, []],
      salaryUp: [salaryUp ?? false, []],
      workPlace: [workPlace ?? null, [Validators.maxLength(200)]],
      workHours: [workHours ?? null, [Validators.maxLength(200)]],
      workHour: [workHour ?? null, [Validators.maxLength(200)]],
      workShift: [workShift ?? false, []],
      workRemoteAllow: [workRemoteAllow ?? false, []],
      workRemoteTypeCode: [
        workRemoteTypeCode ?? null,
        [Validators.required, Validators.maxLength(50)],
      ],
      workRemote: [workRemote ?? null, [Validators.maxLength(200)]],
      workDifferentPlaces: [workDifferentPlaces ?? null, [Validators.maxLength(200)]],
      holidaySystemCode: [
        holidaySystemCode ?? null,
        [Validators.required, Validators.maxLength(50)],
      ],
      workDayCode: [workDayCode ?? null, [Validators.required, Validators.maxLength(50)]],
      workIdentityCode: [workIdentityCode ?? null, [Validators.maxLength(200)]],
      disabilityCategory: [disabilityCategory ?? null, [Validators.maxLength(200)]],
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
