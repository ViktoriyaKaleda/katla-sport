export class StoreItemListItem {
    constructor(
        public id: number,
        public productId: number,
        public productName: string,
        public productCode: string,
        public productCategoryCode: string,
        public quantity: number,
        public isApproved: boolean,
        public createdDate: Date,
        public confirmationDate: Date
    ) { }
}