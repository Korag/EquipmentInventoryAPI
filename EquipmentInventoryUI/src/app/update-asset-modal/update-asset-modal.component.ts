import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { AssetService, UserAssetService, UserService } from 'src/Services';
import { Asset, AssetType, UpdateAsset, User } from '../Models';

@Component({
  selector: 'app-update-asset-modal',
  templateUrl: './update-asset-modal.component.html',
  styleUrls: ['./update-asset-modal.component.css']
})
export class UpdateAssetModalComponent implements OnInit {
  @Input() asset!: Asset;
  @Output() updateAssetEvent = new EventEmitter<Asset>();

  updateAssetForm!: FormGroup;
  loading = false;
  submitted = false;

  users!: Array<User>;
  assetTypes!: AssetType;

  dropdownListTypes: any;
  selectedItemType: any = [];
  dropdownSettingsTypes: IDropdownSettings = {};

  dropdownListUsers: Array<any> = new Array<any>();
  selectedItemsUsers: Array<any> = new Array<any>();
  dropdownSettingsUsers: IDropdownSettings = {};

  constructor(
    private assetContext: AssetService,
    private userContext: UserService,
    private userAssetContext: UserAssetService,

    private activeModal: NgbActiveModal,
    private formBuilder: FormBuilder) { }

  async ngOnInit(): Promise<void> {

console.log(await this.asset);

    this.updateAssetForm = this.formBuilder.group({
      serialNumber: [{ value: this.asset.serialNumber, disabled: false }, Validators.compose([Validators.required, Validators.minLength(2), Validators.maxLength(100)])],
      name: [{ value: this.asset.name, disabled: false }, Validators.compose([Validators.required, Validators.minLength(2), Validators.maxLength(100)])],
      purchasePrice: [{ value: this.asset.purchasePrice, disabled: false }, Validators.compose([Validators.required])],
      presentPrice: [{ value: this.asset.presentPrice, disabled: false }],

      //datePicker
      purchaseDate: [{ value: this.asset.purchaseDate, disabled: false }, Validators.compose([Validators.required])],
    })

    this.users = await this.userContext.getUsers();

    this.dropdownListTypes = [
      { enum: AssetType.Notebook.toString(), enum_value: AssetType[AssetType.Notebook] },
      { enum: AssetType.PC.toString(), enum_value: AssetType[AssetType.PC] },
      { enum: AssetType.Printer.toString(), enum_value: AssetType[AssetType.Printer] },
      { enum: AssetType.Keyboard.toString(), enum_value: AssetType[AssetType.Keyboard] },
      { enum: AssetType.Mouse.toString(), enum_value: AssetType[AssetType.Mouse] },
    ];

    this.selectedItemType = [{ enum: this.asset.type.toString(), enum_value: this.asset.type.toString() }];
    this.dropdownSettingsTypes = {
      singleSelection: true,
      idField: 'enum',
      textField: 'enum_value',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: 1,
      allowSearchFilter: true
    };

    this.dropdownListUsers = [];
    for (let index = 0; index < this.users.length; index++) {
    
      this.dropdownListUsers.push({ id: this.users[index].id, name: this.users[index].firstName + " " + this.users[index].lastName });
    }

    this.selectedItemsUsers = []; 
    for (let index = 0; index < this.asset.owners!.length; index++) {

      let user = this.users.find(x => x.id === this.asset.owners![index]);
      this.selectedItemsUsers.push({ id: user!.id, name: user!.firstName + " " + user!.lastName });
    }

    this.dropdownSettingsUsers = {
      singleSelection: false,
      idField: 'id',
      textField: 'name',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: 3,
      allowSearchFilter: true
    };
  }

  public get f() { return this.updateAssetForm.controls; }

  async closeModal() {
    this.activeModal.close();
  }

  async updateAsset() {
    this.submitted = true;

    if (this.updateAssetForm.invalid) {
      return;
    }

    this.loading = true;

    try {
      const purchaseDateVar = new Date(this.f.purchaseDate.value);
      purchaseDateVar.setSeconds(0, 0);

      var updatedAsset = new UpdateAsset();
      updatedAsset.id = this.asset.id;
      updatedAsset.serialNumber = this.f.serialNumber.value;
      updatedAsset.name = this.f.name.value;
      updatedAsset.purchasePrice = this.f.purchasePrice.value;
      updatedAsset.presentPrice = this.f.presentPrice.value;
     
      updatedAsset.type = this.selectedItemType[0].enum_value;
      updatedAsset.owners = [];

      for (let index = 0; index < this.selectedItemsUsers.length; index++) {
        updatedAsset.owners.push(this.selectedItemsUsers[index].id);
      }

      updatedAsset.purchaseDate = purchaseDateVar;

      await this.assetContext.updateAsset(this.asset.id, updatedAsset);

      this.updateAssetEvent.emit(updatedAsset);
      this.closeModal();
    } catch (err) {
    }

    this.loading = false;
  }
}