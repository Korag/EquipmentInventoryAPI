import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { AssetService, UserAssetService, UserService } from 'src/Services';
import { AddAsset, AddUserAsset, AddUserAssetOwnership, AssetType, User } from '../Models';
import { IDropdownSettings } from 'ng-multiselect-dropdown';

@Component({
  selector: 'app-add-asset-modal',
  templateUrl: './add-asset-modal.component.html',
  styleUrls: ['./add-asset-modal.component.css']
})
export class AddAssetModalComponent implements OnInit {
  @Output() addAssetEvent = new EventEmitter<any>();

  createAssetForm!: FormGroup;
  loading = false;
  submitted = false;

  users!: Array<User>;
  assetTypes!: AssetType;

  purchaseDate?: Date = new Date();

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
    this.createAssetForm = this.formBuilder.group({
      serialNumber: [{ value: "", disabled: false }, Validators.compose([Validators.required, Validators.minLength(2), Validators.maxLength(100)])],
      name: [{ value: "", disabled: false }, Validators.compose([Validators.required, Validators.minLength(2), Validators.maxLength(100)])],
      purchasePrice: [{ value: "", disabled: false }, Validators.compose([Validators.required])],
      presentPrice: [{ value: "", disabled: false }],

      //datePicker
      purchaseDate: [{ value: this.purchaseDate, disabled: false }, Validators.compose([Validators.required])],
    })

    this.users = await this.userContext.getUsers();

    this.dropdownListTypes = [
      { enum: AssetType.Notebook.toString(), enum_value: AssetType[AssetType.Notebook] },
      { enum: AssetType.PC.toString(), enum_value: AssetType[AssetType.PC] },
      { enum: AssetType.Printer.toString(), enum_value: AssetType[AssetType.Printer] },
      { enum: AssetType.Keyboard.toString(), enum_value: AssetType[AssetType.Keyboard] },
      { enum: AssetType.Mouse.toString(), enum_value: AssetType[AssetType.Mouse] },
    ];
    this.selectedItemType = [{ enum: AssetType.Notebook.toString(), enum_value: AssetType[AssetType.Notebook] }];
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

  public get f() { return this.createAssetForm.controls; }

  async closeModal() {
    this.activeModal.close();
  }

  async createAsset() {
    this.submitted = true;

    if (this.createAssetForm.invalid) {
      return;
    }

    this.loading = true;

    try {
      const purchaseDateVar = new Date(this.f.purchaseDate.value);
      purchaseDateVar.setSeconds(0, 0);

      var newAsset = new AddAsset();
      newAsset.serialNumber = this.f.serialNumber.value;
      newAsset.name = this.f.name.value;
      newAsset.purchasePrice = this.f.purchasePrice.value;
      newAsset.presentPrice = this.f.presentPrice.value;
     
      newAsset.type = this.selectedItemType[0].enum;
      newAsset.owners = [];

      for (let index = 0; index < this.selectedItemsUsers.length; index++) {
        newAsset.owners.push(this.selectedItemsUsers[index].id);
      }

      newAsset.purchaseDate = purchaseDateVar;

      console.log(newAsset);
      var createdAsset = await this.assetContext.createAsset(newAsset);

      for (let index = 0; index < newAsset.owners.length; index++) {
        
        var userAssetOwnership = new AddUserAssetOwnership();
        userAssetOwnership.userId = newAsset.owners[index];
        
        userAssetOwnership.asset = new AddUserAsset();
        userAssetOwnership.asset.assetId = createdAsset.id;

        await this.userAssetContext.createUserAssetOwnership(userAssetOwnership);
      }
     

      this.addAssetEvent.emit();
      this.closeModal();
    } catch (err) {
    }

    this.loading = false;
  }
}