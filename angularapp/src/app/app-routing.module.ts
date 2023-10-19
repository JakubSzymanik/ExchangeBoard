import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AccountDetailsComponent } from './account/account-details/account-details.component';
import { AddItemComponent } from './items/add-item/add-item.component';
import { UserItemListComponent } from './items/user-item-list/user-item-list.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuard } from './_guards/auth.guard';
import { ErrorTestingComponent } from './error-testing/error-testing.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children:
    [
        { path: 'items/user-item-list', component: UserItemListComponent },
        { path: 'items/add-item', component: AddItemComponent },
        { path: 'account/details', component: AccountDetailsComponent } //albo dopisać canActivate: .. przy konkretnych linkach
    ]
  },
  { path: 'errors', component: ErrorTestingComponent }, //testowanie błędów, do wywalenia potem
  { path: 'register', component: RegisterComponent },
  { path: '**', component: HomeComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
