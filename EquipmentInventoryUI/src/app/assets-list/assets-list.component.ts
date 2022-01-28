import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AssetService, UserAssetService, UserService } from 'src/Services';
import { Asset, AssetType, ShowAsset, User, UserMinimal } from '../Models';
import { UpdateAssetModalComponent } from '../update-asset-modal/update-asset-modal.component';

@Component({
  selector: 'app-assets-list',
  templateUrl: './assets-list.component.html',
  styleUrls: ['./assets-list.component.css']
})
export class AssetsListComponent implements OnInit {

  assets!: Array<ShowAsset>;
  users!: Array<User>;

  constructor(
    private assetContext: AssetService,
    private userAssetContext: UserAssetService,
    private userContext: UserService,
    private modalService: NgbModal) { }

  async ngOnInit(): Promise<void> {
    let assetsMinimal = await this.assetContext.getAssets();
    this.users = await this.userContext.getUsers();

    this.assets = new Array<ShowAsset>();

    for (let index = 0; index < assetsMinimal.length; index++) {
      let singleAsset = new ShowAsset();
      singleAsset.id = assetsMinimal[index].id;
      singleAsset.serialNumber = assetsMinimal[index].serialNumber;
      singleAsset.name = assetsMinimal[index].name;
      singleAsset.purchasePrice = assetsMinimal[index].purchasePrice;
      singleAsset.presentPrice = assetsMinimal[index].presentPrice;
      singleAsset.purchaseDate = assetsMinimal[index].purchaseDate;
      singleAsset.type = assetsMinimal[index].type.toString();
      singleAsset.owners = new Array<UserMinimal>();

      for (let ind = 0; ind < assetsMinimal[index].owners!.length; ind++) {
        var singleOwner = new UserMinimal();
        var filteredUser = this.users.find(x => x.id === assetsMinimal[index].owners![ind]);

        singleOwner.id = filteredUser!.id;
        singleOwner.firstName = filteredUser!.firstName;
        singleOwner.lastName = filteredUser!.lastName;

        singleAsset.owners.push(singleOwner);
      }

      this.assets.push(singleAsset);
    }
  }

  async deleteAsset(id: string, owners: UserMinimal[]): Promise<void> {

    await this.assetContext.removeAsset(id);

    for (let owner of owners) {
      await this.userAssetContext.removeUserAsset(owner.id);
    }

    this.assets = this.assets.filter(x => x.id !== id);
  }

  async openUpdateAssetModal(id: string): Promise<void> {
    let asset = await this.assetContext.getAssetById(id);

    const modalRef = this.modalService.open(UpdateAssetModalComponent,
      {
        scrollable: true,
        keyboard: false,
        centered: false
      });

    modalRef.componentInstance.asset = asset;
    modalRef.componentInstance.updateAssetEvent.subscribe((asset: Asset) => {

      let assetDtoIndex = this.assets.findIndex(x => asset.id === x.id);

      this.assets[assetDtoIndex].serialNumber = asset.serialNumber;
      this.assets[assetDtoIndex].name = asset.name;
      this.assets[assetDtoIndex].purchasePrice = asset.purchasePrice;
      this.assets[assetDtoIndex].presentPrice = asset.presentPrice;
      this.assets[assetDtoIndex].purchaseDate = asset.purchaseDate;
      this.assets[assetDtoIndex].type = asset.type.toString();
      this.assets[assetDtoIndex].owners = new Array<UserMinimal>();

      for (let index = 0; index < asset.owners!.length; index++) {
        var singleOwner = new UserMinimal();
        var filteredUser = this.users.find(x => x.id === asset.owners![index]);

        singleOwner.id = filteredUser!.id;
        singleOwner.firstName = filteredUser!.firstName;
        singleOwner.lastName = filteredUser!.lastName;

        this.assets[assetDtoIndex].owners!.push(singleOwner);
      }
    });
  }
}
