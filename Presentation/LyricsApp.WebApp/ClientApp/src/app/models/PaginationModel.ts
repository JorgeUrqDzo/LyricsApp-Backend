export interface PaginationModel {
  currentPage: number;
  pages: number;
  pageSize: number;
  totalRecords: number;
}
export interface PagedResult<T> extends PagedResultBase {
  results: T[];
}

export interface PagedResultBase {
  currentPage: number;
  pages: number;
  pageSize: number;
  totalRecords: number;
}
