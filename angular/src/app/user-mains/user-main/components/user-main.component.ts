import { ABP, downloadBlob, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type { GetUserMainsInput, UserMainDto } from '../../../proxy/user-mains/models';
import { UserMainService } from '../../../proxy/user-mains/user-main.service';
@Component({
  selector: 'app-user-main',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './user-main.component.html',
  styles: [],
})
export class UserMainComponent implements OnInit {
  data: PagedResultDto<UserMainDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetUserMainsInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  isExportToExcelBusy = false;

  selected?: UserMainDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: UserMainService,
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

    const setData = (list: PagedResultDto<UserMainDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetUserMainsInput;
  }

  buildForm() {
    const {
      userId,
      name,
      anonymousName,
      loginAccountCode,
      loginMobilePhoneUpdate,
      loginMobilePhone,
      loginEmailUpdate,
      loginEmail,
      loginIdentityNo,
      password,
      systemUserRoleKeys,
      allowSearch,
      dateA,
      extendedInformation,
      dateD,
      sort,
      note,
      status,
      matching,
    } = this.selected || {};

    this.form = this.fb.group({
      userId: [userId ?? null, []],
      name: [name ?? null, [Validators.required, Validators.maxLength(50)]],
      anonymousName: [anonymousName ?? null, [Validators.maxLength(50)]],
      loginAccountCode: [loginAccountCode ?? null, [Validators.required, Validators.maxLength(50)]],
      loginMobilePhoneUpdate: [loginMobilePhoneUpdate ?? null, [Validators.maxLength(50)]],
      loginMobilePhone: [loginMobilePhone ?? null, [Validators.maxLength(50)]],
      loginEmailUpdate: [loginEmailUpdate ?? null, [Validators.maxLength(200)]],
      loginEmail: [loginEmail ?? null, [Validators.maxLength(200)]],
      loginIdentityNo: [loginIdentityNo ?? null, [Validators.maxLength(50)]],
      password: [password ?? null, [Validators.required, Validators.maxLength(200)]],
      systemUserRoleKeys: [systemUserRoleKeys ?? null, [Validators.required]],
      allowSearch: [allowSearch ?? false, [Validators.required]],
      dateA: [dateA ? new Date(dateA) : null, [Validators.required]],
      extendedInformation: [extendedInformation ?? null, [Validators.maxLength(500)]],
      dateD: [dateD ? new Date(dateD) : null, []],
      sort: [sort ?? null, []],
      note: [note ?? null, [Validators.maxLength(500)]],
      status: [status ?? null, [Validators.maxLength(50)]],
      matching: [matching ?? false, []],
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

  update(record: UserMainDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: UserMainDto) {
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
        downloadBlob(result, 'UserMain.xlsx');
      });
  }
}
