export interface ApiSuccess<T> {
  success: boolean;
  message: string;
  model: T;
}

export interface ApiSuccessPaged<T> extends ApiSuccess<T> {
  page: number;
  next: boolean;
  prev: boolean;
  totalItems: number;
  pageItems: number;
}


export interface ApiError {
  success: boolean;
  message: string;
}
