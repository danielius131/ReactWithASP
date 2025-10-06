import create } from 'zustand'
import IStore } from "./interfaces/IStore";
export { useShallow } from 'zustand/react/shallow'

Show usages & Audrius
export const useStore = create<IStore>((set) => ({
    auth: undefined,
    setAuth: (auth) => set({ state ) => ({auth}))
}))