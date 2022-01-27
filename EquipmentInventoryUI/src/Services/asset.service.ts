import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AddAsset, Asset } from 'src/app/Models';
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
}
