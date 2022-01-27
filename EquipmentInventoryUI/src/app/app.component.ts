import { Component, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AddAssetModalComponent } from './add-asset-modal/add-asset-modal.component';
import { AssetsListComponent } from './assets-list/assets-list.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'EquipmentInventoryUI';
  @ViewChild(AssetsListComponent) assetList!: AssetsListComponent;

  constructor(private modalService: NgbModal,
    private router: Router,
    private route: ActivatedRoute) { }

  async ngOnInit(): Promise<void> {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  }

  async openAddAssetModal(): Promise<void> {
    const modalRef = this.modalService.open(AddAssetModalComponent,
      {
        scrollable: true,
        keyboard: false,
        centered: false
      });
    modalRef.componentInstance.addAssetEvent.subscribe(($e: any) => {
        this.router.navigateByUrl('/', {skipLocationChange: true})
        .then(() => this.router.navigate(['/assets']));
    });
  }
}
