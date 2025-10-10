import { Navigate } from "react-router-dom";
import { useStore, useShallow } from "./utils/store";

export function ProtectedRoute({ children }: { children: JSX.Element }) {
    const auth = useStore(useShallow((state) => state.auth))
    if (!auth) return null
    if (!auth?.isAuthenticated) {
        return <Navigate to="/auth/signin" />;
        
    }

    return children;
}