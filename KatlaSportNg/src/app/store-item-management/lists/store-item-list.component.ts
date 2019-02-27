import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StoreItemListItem } from '../models/store-item-list-item';
import { StoreItemService } from '../services/store-item.service';
import { StoreItem } from '../models/store-item';
import { st } from '@angular/core/src/render3';

@Component({
    selector: 'app-store-item-list',
    templateUrl: './store-item-list.component.html',
    styleUrls: ['./store-item-list.component.css']
})
export class StoreItemListComponent implements OnInit {

    hiveId: number;
    hiveSectionId: number;
    confirmedStoreItems: StoreItemListItem[];
    unconfirmedStoreItems: StoreItemListItem[];
    deletedStoreItems: StoreItemListItem[];

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private storeItemService: StoreItemService
    ) { }

    ngOnInit() {
        this.route.params.subscribe(p => {
            this.hiveId = p['hiveId'];
            this.hiveSectionId = p['id'];
            this.storeItemService.getHiveSectionStoreItems(this.hiveSectionId).subscribe(i => {
                this.confirmedStoreItems = i.filter(si => si.isApproved == true && si.isDeleted == false);
                this.unconfirmedStoreItems = i.filter(si => si.isApproved == false && si.isDeleted == false);
                this.deletedStoreItems = i.filter(si => si.isDeleted == true);
            });
        })
    }

    onConfirm(storeItemListItem: StoreItemListItem) {
        this.storeItemService.confirmStoreItem
        (new StoreItem(
            storeItemListItem.id,
            storeItemListItem.productId,
            +this.hiveSectionId,
            storeItemListItem.quantity,
            true
        )).subscribe(i => {
            storeItemListItem.isApproved = true;
            storeItemListItem.confirmationDate = new Date();
            let index = this.unconfirmedStoreItems.indexOf(storeItemListItem);
            if (index !== -1) this.unconfirmedStoreItems.splice(index, 1);
            this.confirmedStoreItems.push(storeItemListItem);
        });
    }

    onDelete(storeItemListItem: StoreItemListItem) {
        this.storeItemService.setHiveStatus(storeItemListItem.id, true).subscribe(i => {
            storeItemListItem.isDeleted = true;
            storeItemListItem.deletionDate = new Date();
            if (storeItemListItem.isApproved == true) {
                if (this.deleteItemFromCollection(storeItemListItem, this.confirmedStoreItems))
                    this.deletedStoreItems.push(storeItemListItem);
            }                
            else {
                if (this.deleteItemFromCollection(storeItemListItem, this.unconfirmedStoreItems))
                    this.deletedStoreItems.push(storeItemListItem);
            }
        });
    }

    deleteItemFromCollection(item: StoreItemListItem, collection: StoreItemListItem[]) {
        let index = collection.indexOf(item);
        if (index !== -1) {
            collection.splice(index, 1);
            return true;
        }
        return false;
    }
}
