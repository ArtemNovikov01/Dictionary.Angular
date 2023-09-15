import { ChangeDetectionStrategy, ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { forkJoin } from 'rxjs';
import { UserIdentityModel } from '../../../shared/models/auth/identity';
import { AuthorizationService } from '../../../shared/services/authorization.service';
import { UserInfoStorage } from '../../storage/user-info-storage';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class HomePageComponent implements OnInit {

  constructor(
    private readonly authorizationService: AuthorizationService,
    public readonly userInfoStorage: UserInfoStorage,
    public cdr: ChangeDetectorRef,
    private router: Router,
  ) { }

  userIdentity: UserIdentityModel;

  ngOnInit(): void {
    forkJoin([
      this.authorizationService.getIdentity(),
    ]).subscribe(([userIdentity]) => {
      this.userIdentity = userIdentity;
      this.userInfoStorage.setUserIdentity(userIdentity);
      this.cdr.detectChanges();
    });
  }

  public signOut(): void {
    this.authorizationService.signOut()
      .pipe()
      .subscribe(() => {
        this.router.navigate(['auth/sign-in']);
      });
  }
}
