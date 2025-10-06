import { Navigate } from "react-router-dom";
import { useStore, useShallow } from "./store";

export function ProtectedRoute({ children }: { children: JSX.Element }) {
    const auth: IAuth | undefined = useStore(useShallow((state: IStore): IAuth | undefined => state.auth)) if (!auth) return null
    if (!auth?.isAuthenticated) {
        return <Navigate to="/auth/signin" />;
        
    }

    return children;
}