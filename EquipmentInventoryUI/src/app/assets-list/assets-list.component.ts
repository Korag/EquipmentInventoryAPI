import { Component, OnInit } from '@angular/core';
import { AssetService, UserService } from 'src/Services';
import { AssetType, ShowAsset, UserMinimal } from '../Models';

@Component({
  selector: 'app-assets-list',
  templateUrl: './assets-list.component.html',
  styleUrls: ['./assets-list.component.css']
})
export class AssetsListComponent implements OnInit {

  assets!: Array<ShowAsset>;

  constructor(
    private assetContext: AssetService,
    private userContext: UserService) {
     }

  async ngOnInit(): Promise<void> {
    let assetsMinimal = await this.assetContext.getAssets();
    let users = await this.userContext.getUsers();
    
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

console.log(AssetType[assetsMinimal[index].type]);
console.log(assetsMinimal[index].type);

      for (let ind = 0; ind < assetsMinimal[index].owners!.length; ind++) {
        var singleOwner = new UserMinimal();
        var filteredUser = users.find(x => x.id === assetsMinimal[index].owners![ind]);

        singleOwner.id = filteredUser!.id;
        singleOwner.firstName = filteredUser!.firstName;
        singleOwner.lastName = filteredUser!.lastName;

        singleAsset.owners.push(singleOwner);
      }

      this.assets.push(singleAsset);
    }
  }
}
