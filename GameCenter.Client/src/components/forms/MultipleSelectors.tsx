import styles from './css/forms.module.css';

export const MultipleSelectors = (props: multipleSelectorsProps) => {
    const select = (item: multipleSelectorModel) => {
        const selected = [...props.selected, item];
        const nonSelected = props.nonSelected.filter(value => value !== item);
        props.onChange(selected, nonSelected);
    }

    const deSelect = (item: multipleSelectorModel) => {
        const nonSelected = [...props.nonSelected, item];
        const selected = props.selected.filter(value => value !== item);
        props.onChange(selected, nonSelected);
    }

    const selectAll = () => {
        const selected = [...props.selected, ...props.nonSelected];
        const nonSelected: multipleSelectorModel[] = [];
        props.onChange(selected, nonSelected);
    }

    const deSelectAll = () => {
        const nonSelected = [...props.selected, ...props.nonSelected];
        const selected: multipleSelectorModel[] = [];
        props.onChange(selected, nonSelected);
    }

    return (
        <div className="mb-3">
            <label>{props.displayName}</label>
            <div className={styles.multipleSelectors}>
                <ul>
                    {props.nonSelected.map(item => 
                    <li key={item.key} onClick={() => select(item)}>{item.value}</li>)}
                </ul>
                <div className={styles.multipleSelectorsButtons}>
                        <button type="button" onClick={selectAll}>{'>>'}</button>
                        <button type="button" onClick={deSelectAll}>{'<<'}</button>
                </div>
                <ul>
                    {props.selected.map(item => 
                    <li key={item.key} onClick={() => deSelect(item)}>{item.value}</li>)}
                </ul>
            </div>
        </div>
        

    )
}

interface multipleSelectorsProps {
    displayName: string;
    selected: multipleSelectorModel[];
    nonSelected: multipleSelectorModel[];
    onChange(selected: multipleSelectorModel[], 
        nonSelected: multipleSelectorModel[]): void;
}

export interface multipleSelectorModel {
    key: number;
    value: string;
}