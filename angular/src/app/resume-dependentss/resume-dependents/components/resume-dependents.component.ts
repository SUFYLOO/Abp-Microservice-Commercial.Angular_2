import { ABP, downloadBlob, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetResumeDependentssInput,
  ResumeDependentsDto,
} from '../../../proxy/resume-dependentss/models';
import { ResumeDependentsService } from '../../../proxy/resume-dependentss/resume-dependents.service';
@Component({
  selector: 'app-resume-dependents',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './resume-dependents.component.html',
  styles: [],
})
export class ResumeDependentsComponent implements OnInit {
  data: PagedResultDto<ResumeDependentsDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetResumeDependentssInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  isExportToExcelBusy = false;

  selected?: ResumeDependentsDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: ResumeDependentsService,
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

    const setData = (list: PagedResultDto<ResumeDependentsDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetResumeDependentssInput;
  }

  buildForm() {
    const {
      resumeMainId,
      name,
      identityNo,
      kinshipCode,
      birthDate,
      address,
      mobilePhone,
      extendedInformation,
      dateA,
      dateD,
      sort,
      note,
      status,
    } = this.selected || {};

    this.form = this.fb.group({
      resumeMainId: [resumeMainId ?? null, []],
      name: [name ?? null, [Validators.required, Validators.maxLength(50)]],
      identityNo: [identityNo ?? null, [Validators.maxLength(50)]],
      kinshipCode: [kinshipCode ?? null, [Validators.required, Validators.maxLength(50)]],
      birthDate: [birthDate ? new Date(birthDate) : null, [Validators.required]],
      address: [address ?? null, [Validators.maxLength(200)]],
      mobilePhone: [mobilePhone ?? null, [Validators.maxLength(50)]],
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

  update(record: ResumeDependentsDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: ResumeDependentsDto) {
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
        downloadBlob(result, 'ResumeDependents.xlsx');
      });
  }
}
