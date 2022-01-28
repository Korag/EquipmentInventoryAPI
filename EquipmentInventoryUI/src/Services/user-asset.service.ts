import { Injectable } from '@angular/core';
import { UserAssetOwnership } from 'src/app/Models';
import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { AddUserAssetOwnership } from 'src/app/Models/addUserAssetOwnership';

@Injectable({
  providedIn: 'root'
})
export class UserAssetService {

  constructor(private http: HttpClient) { }

  public async createUserAssetOwnership(userAsset: AddUserAssetOwnership): Promise<UserAssetOwnership> {
    var createdUserAssetsOwnership = new UserAssetOwnership();

    await this.http.post<UserAssetOwnership>(`${environment.apiUrl}/UserAssetOwnership/Aquire`, userAsset)
      .pipe(map(result => {
        createdUserAssetsOwnership = result;
      })).toPromise();

    return await createdUserAssetsOwnership;
  }

  public async getUserAssetOwnershipById(id: string): Promise<UserAssetOwnership> {
    var userAssetsOwnership = new UserAssetOwnership();

    await this.http.get<UserAssetOwnership>(`${environment.apiUrl}/UserAssetOwnership/${id}`, {})
      .pipe(map(result => {
        userAssetsOwnership = result;
      })).toPromise();

    return await userAssetsOwnership;
  }

  public async removeUserAsset(id: string): Promise<void> {
 
    await this.http.delete(`${environment.apiUrl}/UserAssetOwnership/${id}`, {}).toPromise();
  }

  public async disposeUserAssetOwnership(userId: string, userAssetId: string): Promise<void> {
 
    await this.http.put(`${environment.apiUrl}/UserAssetOwnership/Dispose?id=${userId}`, {userId: userId, userAssetId: userAssetId }).toPromise();
  }
}
