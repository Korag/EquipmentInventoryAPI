import { AssetType } from "./assetType";

export class AddAsset{
    serialNumber!: string;
    name!: string;
    purchasePrice!: number;
    presentPrice?: number;
    purchaseDate!: Date;
    type!: AssetType;
    owners?: Array<string>;

    constructor() {

    }
}