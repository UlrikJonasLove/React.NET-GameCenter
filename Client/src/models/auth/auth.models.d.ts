export interface claim {
    name: string;
    value: string;
}

export interface authCredentials {
    email: string;
    password: string;
}

export interface authResponse {
    token: string;
    expiration: Date;
}