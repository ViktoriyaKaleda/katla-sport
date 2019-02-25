export class StoreItem {
    constructor(
        public id: number,
        public productId: number,
        public productName: string,
        public productCode: string,
        public productCategoryCode: string,
        public quantity: number
    ) { }
}