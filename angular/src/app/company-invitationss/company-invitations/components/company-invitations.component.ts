import { ABP, downloadBlob, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetCompanyInvitationssInput,
  CompanyInvitationsDto,
} from '../../../proxy/company-invitationss/models';
import { CompanyInvitationsService } from '../../../proxy/company-invitationss/company-invitations.service';
@Component({
  selector: 'app-company-invitations',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './company-invitations.component.html',
  styles: [],
})
export class CompanyInvitationsComponent implements OnInit {
  data: PagedResultDto<CompanyInvitationsDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetCompanyInvitationssInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  isExportToExcelBusy = false;

  selected?: CompanyInvitationsDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: CompanyInvitationsService,
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

    const setData = (list: PagedResultDto<CompanyInvitationsDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetCompanyInvitationssInput;
  }

  buildForm() {
    const {
      companyMainId,
      companyJobId,
      openAllJob,
      userMainId,
      userMainName,
      userMainLoginMobilePhone,
      userMainLoginEmail,
      userMainLoginIdentityNo,
      sendTypeCode,
      sendStatusCode,
      resumeFlowStageCode,
      isRead,
      userCompanyBindId,
      resumeSnapshotId,
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
      openAllJob: [openAllJob ?? false, [Validators.required]],
      userMainId: [userMainId ?? null, []],
      userMainName: [userMainName ?? null, [Validators.maxLength(50)]],
      userMainLoginMobilePhone: [userMainLoginMobilePhone ?? null, [Validators.maxLength(50)]],
      userMainLoginEmail: [userMainLoginEmail ?? null, [Validators.maxLength(200)]],
      userMainLoginIdentityNo: [userMainLoginIdentityNo ?? null, [Validators.maxLength(50)]],
      sendTypeCode: [sendTypeCode ?? null, [Validators.required, Validators.maxLength(50)]],
      sendStatusCode: [sendStatusCode ?? null, [Validators.required, Validators.maxLength(50)]],
      resumeFlowStageCode: [
        resumeFlowStageCode ?? null,
        [Validators.required, Validators.maxLength(50)],
      ],
      isRead: [isRead ?? false, [Validators.required]],
      userCompanyBindId: [userCompanyBindId ?? null, []],
      resumeSnapshotId: [resumeSnapshotId ?? null, []],
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

  update(record: CompanyInvitationsDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: CompanyInvitationsDto) {
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
        downloadBlob(result, 'CompanyInvitations.xlsx');
      });
  }
}
