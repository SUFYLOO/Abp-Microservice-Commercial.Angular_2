import { ABP, downloadBlob, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetCompanyJobConditionsInput,
  CompanyJobConditionDto,
} from '../../../proxy/company-job-conditions/models';
import { CompanyJobConditionService } from '../../../proxy/company-job-conditions/company-job-condition.service';
@Component({
  selector: 'app-company-job-condition',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './company-job-condition.component.html',
  styles: [],
})
export class CompanyJobConditionComponent implements OnInit {
  data: PagedResultDto<CompanyJobConditionDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetCompanyJobConditionsInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  isExportToExcelBusy = false;

  selected?: CompanyJobConditionDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: CompanyJobConditionService,
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

    const setData = (list: PagedResultDto<CompanyJobConditionDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetCompanyJobConditionsInput;
  }

  buildForm() {
    const {
      companyMainId,
      companyJobId,
      workExperienceYearCode,
      educationLevel,
      majorDepartmentCategory,
      languageCondition,
      computerExpertiseEtc,
      professionalLicense,
      professionalLicenseEtc,
      workSkills,
      workSkillsEtc,
      drvingLicense,
      etcCondition,
      extendedInformation,
      dateA,
      dateD,
      sort,
      note,
      status,
    } = this.selected || {};

    this.form = this.fb.group({
      companyMainId: [companyMainId ?? null, [Validators.required]],
      companyJobId: [companyJobId ?? null, []],
      workExperienceYearCode: [
        workExperienceYearCode ?? null,
        [Validators.required, Validators.maxLength(50)],
      ],
      educationLevel: [educationLevel ?? null, [Validators.maxLength(500)]],
      majorDepartmentCategory: [majorDepartmentCategory ?? null, [Validators.maxLength(500)]],
      languageCondition: [languageCondition ?? null, [Validators.maxLength(4000)]],
      computerExpertiseEtc: [computerExpertiseEtc ?? null, [Validators.maxLength(4000)]],
      professionalLicense: [professionalLicense ?? null, [Validators.maxLength(500)]],
      professionalLicenseEtc: [professionalLicenseEtc ?? null, [Validators.maxLength(5000)]],
      workSkills: [workSkills ?? null, [Validators.maxLength(500)]],
      workSkillsEtc: [workSkillsEtc ?? null, [Validators.maxLength(5000)]],
      drvingLicense: [drvingLicense ?? null, [Validators.maxLength(4000)]],
      etcCondition: [etcCondition ?? null, [Validators.maxLength(4000)]],
      extendedInformation: [extendedInformation ?? null, [Validators.maxLength(500)]],
      dateA: [dateA ?? '1900/1/1', []],
      dateD: [dateD ?? '2099/12/31', []],
      sort: [sort ?? null, []],
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

  update(record: CompanyJobConditionDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: CompanyJobConditionDto) {
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
        downloadBlob(result, 'CompanyJobCondition.xlsx');
      });
  }
}
