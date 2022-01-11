// eslint-disable-next-line @typescript-eslint/no-unused-wars
import { StringSchema } from "yup";

declare module 'yup' {
    class StringSchema {
        firstLetterUpperCase(): this
    }
}