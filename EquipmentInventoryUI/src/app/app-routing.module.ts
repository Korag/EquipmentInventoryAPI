import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AssetsListComponent } from './assets-list/assets-list.component';
import { OwnershipQueryComponent } from './ownership-query/ownership-query.component';
import { UserOwnershipListComponent } from './user-ownership-list/user-ownership-list.component';

const routes: Routes = [

  {
    path: 'assets',
    component: AssetsListComponent
  },
  {
    path: 'ownership',
    component: UserOwnershipListComponent
  },
  {
    path: 'ownershipQuery',
    component: OwnershipQueryComponent
  },

  {
    path: '**',
    redirectTo: "assets"
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }


