import { AssetType, UserMinimal } from ".";
import { Asset } from "./asset";

export class ShowAsset{
    id!: string;
    serialNumber!: string;
    name!: string;
    purchasePrice!: number;
    presentPrice?: number;
    purchaseDate!: Date;
    type!: string;
    owners?: Array<UserMinimal>;

    constructor() {

    }
}