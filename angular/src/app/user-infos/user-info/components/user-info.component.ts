import { ABP, downloadBlob, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type { GetUserInfosInput, UserInfoDto } from '../../../proxy/user-infos/models';
import { UserInfoService } from '../../../proxy/user-infos/user-info.service';
@Component({
  selector: 'app-user-info',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './user-info.component.html',
  styles: [],
})
export class UserInfoComponent implements OnInit {
  data: PagedResultDto<UserInfoDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetUserInfosInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  isExportToExcelBusy = false;

  selected?: UserInfoDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: UserInfoService,
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

    const setData = (list: PagedResultDto<UserInfoDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetUserInfosInput;
  }

  buildForm() {
    const {
      userMainId,
      nameC,
      nameE,
      identityNo,
      birthDate,
      sexCode,
      bloodCode,
      placeOfBirthCode,
      passportNo,
      nationalityCode,
      residenceNo,
      extendedInformation,
      dateA,
      dateD,
      sort,
      note,
      status,
    } = this.selected || {};

    this.form = this.fb.group({
      userMainId: [userMainId ?? null, []],
      nameC: [nameC ?? null, [Validators.required, Validators.maxLength(50)]],
      nameE: [nameE ?? null, [Validators.maxLength(200)]],
      identityNo: [identityNo ?? null, [Validators.maxLength(50)]],
      birthDate: [birthDate ? new Date(birthDate) : null, []],
      sexCode: [sexCode ?? null, [Validators.maxLength(50)]],
      bloodCode: [bloodCode ?? null, [Validators.maxLength(50)]],
      placeOfBirthCode: [placeOfBirthCode ?? null, [Validators.maxLength(50)]],
      passportNo: [passportNo ?? null, [Validators.maxLength(50)]],
      nationalityCode: [nationalityCode ?? null, [Validators.maxLength(50)]],
      residenceNo: [residenceNo ?? null, [Validators.maxLength(50)]],
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

  update(record: UserInfoDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: UserInfoDto) {
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
        downloadBlob(result, 'UserInfo.xlsx');
      });
  }
}
