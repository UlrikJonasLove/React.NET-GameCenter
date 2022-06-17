import React from 'react';
import { claim } from '../../models/auth/auth.models';

export const AuthContext = React.createContext<{
    claims: claim[];
    update(claims: claim[]): void;
}>({claims: [], update: () => {}});