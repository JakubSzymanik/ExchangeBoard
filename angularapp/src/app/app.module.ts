import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavbarComponent } from './navbar/navbar.component';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { RegisterComponent } from './register/register.component';
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './home/home.component';
import { AccountDetailsComponent } from './account/account-details/account-details.component';
import { AddItemComponent } from './items/add-item/add-item.component';
import { UserItemListComponent } from './items/user-item-list/user-item-list.component';
import { ToastrModule } from 'ngx-toastr';
import { ErrorTestingComponent } from './error-testing/error-testing.component';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { UserListComponent } from './users/user-list/user-list.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    RegisterComponent,
    HomeComponent,
    AccountDetailsComponent,
    AddItemComponent,
    UserItemListComponent,
    ErrorTestingComponent,
    NotFoundComponent,
    ServerErrorComponent,
    UserListComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    BsDropdownModule.forRoot(),
    AppRoutingModule,
    ToastrModule.forRoot({
      positionClass: 'toastr-top-right'
    })
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
