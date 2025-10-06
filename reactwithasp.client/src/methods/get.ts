import { fechRequest, getHeaders, type ApiResponse } from "./utils";

export async function methodGet<T>(endpoint: string): Promise<ApiResopnes<T> | undefined> {
    return await fechRequest<T>(endpoint, getHeaders());
}