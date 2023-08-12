import { ABP, downloadBlob, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type { GetResumeSkillsInput, ResumeSkillDto } from '../../../proxy/resume-skills/models';
import { ResumeSkillService } from '../../../proxy/resume-skills/resume-skill.service';
@Component({
  selector: 'app-resume-skill',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './resume-skill.component.html',
  styles: [],
})
export class ResumeSkillComponent implements OnInit {
  data: PagedResultDto<ResumeSkillDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetResumeSkillsInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  isExportToExcelBusy = false;

  selected?: ResumeSkillDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: ResumeSkillService,
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

    const setData = (list: PagedResultDto<ResumeSkillDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetResumeSkillsInput;
  }

  buildForm() {
    const {
      resumeMainId,
      computerSkills,
      computerSkillsEtc,
      chineseTypingSpeed,
      chineseTypingCode,
      englishTypingSpeed,
      professionalLicense,
      professionalLicenseEtc,
      workSkills,
      workSkillsEtc,
      extendedInformation,
      dateA,
      dateD,
      sort,
      note,
      status,
    } = this.selected || {};

    this.form = this.fb.group({
      resumeMainId: [resumeMainId ?? null, []],
      computerSkills: [computerSkills ?? null, [Validators.maxLength(500)]],
      computerSkillsEtc: [computerSkillsEtc ?? null, [Validators.maxLength(500)]],
      chineseTypingSpeed: [chineseTypingSpeed ?? null, [Validators.required]],
      chineseTypingCode: [
        chineseTypingCode ?? null,
        [Validators.required, Validators.maxLength(50)],
      ],
      englishTypingSpeed: [englishTypingSpeed ?? null, [Validators.required]],
      professionalLicense: [professionalLicense ?? null, [Validators.maxLength(500)]],
      professionalLicenseEtc: [professionalLicenseEtc ?? null, [Validators.maxLength(500)]],
      workSkills: [workSkills ?? null, [Validators.maxLength(500)]],
      workSkillsEtc: [workSkillsEtc ?? null, [Validators.maxLength(500)]],
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

  update(record: ResumeSkillDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: ResumeSkillDto) {
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
        downloadBlob(result, 'ResumeSkill.xlsx');
      });
  }
}
