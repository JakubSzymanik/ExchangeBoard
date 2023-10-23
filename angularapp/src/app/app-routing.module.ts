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
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: //po to żeby nie powtarzać authguarda na wszystkich ścieżkach
    [
        {
          path: 'items',
          children:
          [
              { path: 'items/user-item-list', component: UserItemListComponent },
              { path: 'items/add-item', component: AddItemComponent }
          ]
        },
        { path: 'account/details', component: AccountDetailsComponent } //albo dopisać canActivate: .. przy konkretnych linkach
    ]},
  { path: 'errors',
    children:
      [
        { path: 'testing', component: ErrorTestingComponent },
        { path: 'not-found', component: NotFoundComponent },
        { path: 'server-error', component: ServerErrorComponent }
    ]},
  { path: 'register', component: RegisterComponent },
  { path: '**', component: HomeComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
