describe('Notes App', () => {
  beforeEach(() => {
    cy.visit('http://localhost:4200');
  });

  it('should create a note and display it in the list', () => {
    cy.contains('New Note').click();

    cy.get('input[formControlName="title"]').type('Test Note');
    cy.get('textarea[formControlName="content"]').type('This is a test note content');

    cy.contains('Save').click();

    cy.contains('Test Note').should('be.visible');
    cy.contains('This is a test note content').should('be.visible');
  });

  it('should show error when creating a note with spaces only in title', () => {
    cy.contains('New Note').click();

    cy.get('input[formControlName="title"]').type('     ');
    cy.get('textarea[formControlName="content"]').type('Some content');

    cy.contains('Save').click();

    cy.url().should('include', '/notes/new');
    cy.contains('Title and content cannot be empty or contain only spaces').should('be.visible');
  });

  it('should show error when editing a note with spaces only in content', () => {
    cy.contains('New Note').click();
    cy.get('input[formControlName="title"]').type('Note to Edit');
    cy.get('textarea[formControlName="content"]').type('Original content');
    cy.contains('Save').click();

    cy.contains('Note to Edit').parents('.note-card').find('.btn-edit').click();

    cy.get('textarea[formControlName="content"]').clear().type('     ');

    cy.contains('Save').click();

    cy.url().should('include', '/edit');
    cy.contains('Title and content cannot be empty or contain only spaces').should('be.visible');
  });
});
