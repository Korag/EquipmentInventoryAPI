import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AddAssetModalComponent } from './add-asset-modal/add-asset-modal.component';
import { AssetsListComponent } from './assets-list/assets-list.component';

import { OwlDateTimeModule, OwlNativeDateTimeModule, OWL_DATE_TIME_LOCALE } from 'ng-pick-datetime';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { UpdateAssetModalComponent } from './update-asset-modal/update-asset-modal.component';

@NgModule({
  declarations: [
    AppComponent,
    AddAssetModalComponent,
    AssetsListComponent,
    UpdateAssetModalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    OwlDateTimeModule,
    OwlNativeDateTimeModule,
    BrowserAnimationsModule,
    NgMultiSelectDropDownModule.forRoot()
  ],
  providers: [
    { provide: OWL_DATE_TIME_LOCALE, useValue: 'in' }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
