import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AccountDetailsComponent } from './account/account-details/account-details.component';
import { AddItemComponent } from './items/add-item/add-item.component';
import { UserItemListComponent } from './items/user-item-list/user-item-list.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'items/user-item-list', component: UserItemListComponent },
  { path: 'items/add-item', component: AddItemComponent },
  { path: 'account/details', component: AccountDetailsComponent },
  { path: 'register', component: RegisterComponent },
  { path: '**', component: HomeComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
