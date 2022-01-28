import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AddAsset, Asset, UpdateAsset } from 'src/app/Models';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AssetService {

  constructor(private http: HttpClient) { }

  public async createAsset(asset: AddAsset): Promise<Asset> {
    var createdAsset = new Asset();

    await this.http.post<Asset>(`${environment.apiUrl}/Asset`, asset)
      .pipe(map(result => {
        createdAsset = result;
      })).toPromise();

    return await createdAsset;
  }

  public async getAssets(): Promise<Array<Asset>> {
    var assets = new Array<Asset>();

    await this.http.get<Array<Asset>>(`${environment.apiUrl}/Asset`, {})
      .pipe(map(result => {
        assets = result;
      })).toPromise();

    return await assets;
  }

  public async removeAsset(id: string): Promise<void> {
 
    await this.http.delete(`${environment.apiUrl}/Asset/${id}`, {}).toPromise();
  }

  public async getAssetById(id: string): Promise<Asset> {
    var asset = new Asset();

    await this.http.get<Asset>(`${environment.apiUrl}/Asset/${id}`, {})
      .pipe(map(result => {
        asset = result;
      })).toPromise();

    return await asset;
  }

  public async updateAsset(id: string, asset: UpdateAsset): Promise<void> {
    await this.http.put(`${environment.apiUrl}/Asset/${id}`, asset).toPromise();
  }
}
