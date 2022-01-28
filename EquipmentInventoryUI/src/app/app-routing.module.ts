import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AssetsListComponent } from './assets-list/assets-list.component';

const routes: Routes = [

  {
    path: 'assets',
    component: AssetsListComponent
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


