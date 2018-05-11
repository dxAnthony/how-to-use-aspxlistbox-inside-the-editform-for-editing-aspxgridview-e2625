import { Selector } from 'testcafe';

fixture`Getting Started`
    .page`https://codecentral.devexpress.com/128543494/`

test('My first test', async t => {
    await t
        .click("#ASPxGridView1_DXCBtn3") //start editing;

    const listBoxRowsCount = Selector(".dxeListBoxItemRow_DevEx").count;
    const selectedNodesCount = Selector(".dxWeb_edtCheckBoxChecked_DevEx").count;

    await t
        .expect(listBoxRowsCount).gt(1)
        .expect(selectedNodesCount).eql(2);
});