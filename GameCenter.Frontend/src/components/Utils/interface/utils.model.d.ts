interface genericListProps{
    list: any;
    loadingUI?: ReactElement;
    emptyListUI?: ReactElement;
    children: ReactElement;
}

interface buttonProps{
    children: React.ReactNode;
    onClick?(): void;
    type:"button" | "submit";
}
