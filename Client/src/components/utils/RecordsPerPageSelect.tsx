import { recordsPerPageOptions } from "../../constants/GameCenterVariables";

export const RecordsPerPageSelect = (props: recordsPerPageSelectProps) => {
    return (
        <div className="mb-3" style={{width: '150px'}}>
                <label>Records Per Page:</label>
                <select className="form-select" 
                defaultValue={5}
                onChange={e => {
                    props.onChange(parseInt(e.target.value, 10))
                    
                } }>
                    {recordsPerPageOptions.map(option => 
                        <option key={option.key} 
                            value={option.value}>{option.value}</option>
                        )}
                </select>
            </div>
    )
};

interface recordsPerPageSelectProps {
    onChange(recordsPerPage: number): void;
}