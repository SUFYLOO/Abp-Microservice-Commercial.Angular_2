import { ABP, downloadBlob, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type { GetResumeMainsInput, ResumeMainDto } from '../../../proxy/resume-mains/models';
import { ResumeMainService } from '../../../proxy/resume-mains/resume-main.service';
@Component({
  selector: 'app-resume-main',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './resume-main.component.html',
  styles: [],
})
export class ResumeMainComponent implements OnInit {
  data: PagedResultDto<ResumeMainDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetResumeMainsInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  isExportToExcelBusy = false;

  selected?: ResumeMainDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: ResumeMainService,
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

    const setData = (list: PagedResultDto<ResumeMainDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetResumeMainsInput;
  }

  buildForm() {
    const {
      userMainId,
      resumeName,
      marriageCode,
      militaryCode,
      disabilityCategoryCode,
      specialIdentityCode,
      main,
      autobiography1,
      autobiography2,
      extendedInformation,
      dateA,
      dateD,
      sort,
      note,
      status,
    } = this.selected || {};

    this.form = this.fb.group({
      userMainId: [userMainId ?? null, []],
      resumeName: [resumeName ?? null, [Validators.required, Validators.maxLength(50)]],
      marriageCode: [marriageCode ?? null, [Validators.maxLength(50)]],
      militaryCode: [militaryCode ?? null, [Validators.maxLength(50)]],
      disabilityCategoryCode: [disabilityCategoryCode ?? null, [Validators.maxLength(50)]],
      specialIdentityCode: [specialIdentityCode ?? null, [Validators.maxLength(50)]],
      main: [main ?? false, [Validators.required]],
      autobiography1: [autobiography1 ?? null, [Validators.maxLength(4000)]],
      autobiography2: [autobiography2 ?? null, [Validators.maxLength(4000)]],
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

  update(record: ResumeMainDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: ResumeMainDto) {
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
        downloadBlob(result, 'ResumeMain.xlsx');
      });
  }
}
